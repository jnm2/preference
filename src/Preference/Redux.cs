using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace Preference
{
    public static class Redux
    {
        public static TView Bootstrap<TState, TView>(TState initialState, Func<Action<object>, TView> createViewGivenDispatchCallback)
        {
            if (createViewGivenDispatchCallback is null)
                throw new ArgumentNullException(nameof(createViewGivenDispatchCallback));

            var renderMethod = typeof(TView).GetMethod(
                "Render",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy,
                null,
                new[] { typeof(TState) },
                null);

            if (renderMethod is null || renderMethod.IsGenericMethod)
            {
                throw new ArgumentException($"{typeof(TView).Name} must have a single non-generic public instance method named ‘Render’ with a parameter of type {typeof(TState).Name}.");
            }

            var reduceMethod = typeof(TState).GetMethod(
                "Reduce",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy,
                null,
                new[] { typeof(object) },
                null);

            if (reduceMethod is null || reduceMethod.IsGenericMethod || reduceMethod.ReturnType != typeof(TState))
            {
                throw new ArgumentException($"{typeof(TState).Name} must have a single non-generic public instance method named ‘Reduce’ with a parameter of type System.Object and with the return type {typeof(TState).Name}.");
            }

            var handler = new DispatchHandler<TState>(
                initialState,
                reducer: (Func<TState, object, TState>)reduceMethod.CreateDelegate(typeof(Func<TState, object, TState>)));

            var view = createViewGivenDispatchCallback.Invoke(handler.Dispatch);

            handler.Initialize(
                SynchronizationContext.Current,
                render: (Action<TState>)renderMethod.CreateDelegate(typeof(Action<TState>), view));

            return view;
        }

        private sealed class DispatchHandler<TState>
        {
            private readonly Func<TState, object, TState> reducer;
            private TState state;
            private SynchronizationContext renderContext;
            private Action<TState> render;
            private bool pendingRender;

            public DispatchHandler(TState initialState, Func<TState, object, TState> reducer)
            {
                state = initialState;
                this.reducer = reducer;
            }

            public void Initialize(SynchronizationContext renderContext, Action<TState> render)
            {
                this.renderContext = renderContext ?? AsyncOperationManager.SynchronizationContext;
                this.render = render;
                QueueRender();
            }

            private void QueueRender()
            {
                if (pendingRender) return;
                pendingRender = true;
                renderContext.Post(Render, state: null);
            }

            private void Render(object state)
            {
                pendingRender = false;
                render.Invoke(this.state);
            }

            public void Dispatch(object action)
            {
                if (SynchronizationContext.Current != renderContext)
                    throw new NotImplementedException("Reducing from background threads is not implemented.");

                if (action is null) return;

                var newState = reducer.Invoke(state, action);
                if (ReferenceEquals(newState, state)) return;

                state = newState;
                QueueRender();
            }
        }
    }
}
