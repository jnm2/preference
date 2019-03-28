# Preference

This is a personal tool that I built because there were so many good candidates for the .NET Foundation 2019 board! Ranking most of them was so hard that I wrote this desktop app. It randomly selects pairs of candidates and pulls up the `https://election.dotnetfoundation.org/campaign-2019/{nameSlug}.html#site_container` pages (linked from https://election.dotnetfoundation.org/candidates) side by side and records which one I choose. After each choice, if the list isn’t totally ordered yet, it pulls up two more at random. (It retries at random until it finds a pair whose order isn’t already known transitively.) Once a total ordering is achieved, the app lists the names in descending order of preference. All the individual choices that were made are listed underneath.

Comparing two mission statements at a time made my decisions much clearer. The results feel right.

I’m also trying out a variant of Redux-style UI state management as a personal experiment. It’s all very ad-hoc.

## If you want to play with it

To build and run the app, you’ll need to create the file `src\Preference\CandidateNames.txt` and fill it with one name per line. I gitignored it for obvious reasons.

The app has served its purpose for me for the time being, so right now I’m not planning to expand it or document it besides what I had time to write here.
