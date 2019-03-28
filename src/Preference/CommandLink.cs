using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Preference
{
    public sealed class CommandLink : Button
    {
        public CommandLink()
        {
            base.FlatStyle = FlatStyle.System;
        }

        protected override Size DefaultSize => new Size(185, 50);

        protected override CreateParams CreateParams
        {
            get
            {
                var p = base.CreateParams;
                p.Style |= BS_COMMANDLINK;
                return p;
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            if (!string.IsNullOrEmpty(noteText)) SetButtonNote();
        }

        private string noteText;

        /// <summary>
        /// Gets or sets the command link’s supplementary text (underneath the label text set via the Text property).
        /// </summary>
        [Category("Appearance"), DefaultValue(null)]
        [Description("Gets or sets the command link’s supplementary text (underneath the label text set via the Text property).")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Bindable(true), SettingsBindable(true)]
        public string NoteText
        {
            get => noteText;
            set
            {
                if (noteText == value) return;
                noteText = value;
                if (IsHandleCreated) SetButtonNote();
            }
        }

        private void SetButtonNote()
        {
            if (SendMessage(new HandleRef(this, Handle), BCM.SETNOTE, IntPtr.Zero, noteText) == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
        }

        #region P/Invoke
#pragma warning disable IDE1006 // Naming Styles

        private const int BS_COMMANDLINK = 0x0000000E;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(HandleRef hWnd, BCM Msg, IntPtr wParam, string lParam);

        private enum BCM : uint
        {
            SETNOTE = 0x1609
        }

#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Removed properties

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoEllipsis => base.AutoEllipsis;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoSize => base.AutoSize;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoSizeMode AutoSizeMode => base.AutoSizeMode;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor => base.BackColor;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage => base.BackgroundImage;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout => base.BackgroundImageLayout;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatButtonAppearance FlatAppearance => base.FlatAppearance;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new FlatStyle FlatStyle => base.FlatStyle;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font => base.Font;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor => base.ForeColor;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image => base.Image;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment ImageAlign => base.ImageAlign;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int ImageIndex => base.ImageIndex;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string ImageKey => base.ImageKey;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageList ImageList => base.ImageList;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding => base.Padding;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new RightToLeft RightToLeft => base.RightToLeft;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContentAlignment TextAlign => base.TextAlign;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TextImageRelation TextImageRelation => base.TextImageRelation;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseCompatibleTextRendering => base.UseCompatibleTextRendering;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseMnemonic => base.UseMnemonic;

        [Obsolete, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool UseVisualStyleBackColor => base.UseVisualStyleBackColor;

        #endregion
    }
}
