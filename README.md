powershell-environment-vars
===========================

This is the solution for a PowerShell module which provides the following cmdlets:

## Push-Environment

`Push-Environment -Description "Some description"`

This pushes the current environment variables and Host Window Title onto a
stack.

## Pop-Environment

`Pop-Environment`

This pops the most recently pushed environment variables and Host Window Title
and restores them.

## Why is this useful?

Sometimes it is necessary to change things like the PATH for the duration of a
script, for example when you want to use MSBuild from a PowerShell script from
either Visual Studio or the Windows SDK, which is surprisingly difficult
otherwise (if you have Visual C++ which needs building). Since it's horribly
bad form to pollute someone's shell with extra environment variables and so
forth, it's you need a way of reverting to a known state after script
execution.

This is heavily inspired (read, almost exactly the same as) the 
[PowerShell Community Extension](http://pscx.codeplex.com) version of these Cmdlets, but
extracted into a single, no-dependency assembly targetting .NET 4.0 that
doesn't pull in all the other pieces if you don't need them. In addition, it's
been modified slightly such that it includes the Host Window Title as part of
the environment.
