# cdsi
Clinical decision support for immunizations.

This is the nth iteration of this project. Maybe this time!

## Thoughts On Architecture

Everything I said before is absolute hogwash. The real progress was made
when I embraced the message-passing model.

## Thoughts on the Development Process

Moving from a monorepo to using supporting packages was fine until 
my personal access token expired. It has taken me two days to figure 
out how to add my new PAT to Visual Studio to access the OpenCdsi
NuGet package store. 

Here is a [clue](https://stackoverflow.com/questions/62166035/how-to-use-github-nuget-packages-on-visual-studio-2019) 
if you have the same problem. I've also added an example `NuGet.config` to the solution
to help you along.
