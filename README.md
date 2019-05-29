# VS 2019 Async Refactoring Bug

Repro project for an annoying bug in VS 2019's "Make method async" refactoring. When applying the "Make method async" refactoring,
Visual Studio appends an `Async` suffix to the method. This is a little opinionated, but fair enough.

_The problem is that it is doing it to methods that implement interfaces from NuGet packages. 💥_ It can't change the interface itself, because it doesn't have access to the source,
but it does change every other implementation of the interface. ☠☠☠

## Steps to reproduce

1. Check out the master branch and open the solution in VS 2019.
2. Add an `await` keyword before the [call to `GetGreeting()`](https://github.com/bennor/AsyncRefactoringBug/blob/ca8b00c7fb5eaa1b3fab141033a8b17456d775ac/GreetingRequest.cs#L21) in _GreetingRequest.cs_.
3. Apply the **"Make method async"** refactoring when VS suggests it
4. Both _GreetingRequest.cs_ and _SomeOtherRequest.cs_ will now be broken. 😞 (Their `Handle` methods have been renamed to `HandleAsync`, which no longer implements the MediatR `IRequestHandler` interface correctly.)

Alternatively, check out the [`after-refactoring` branch](https://github.com/bennor/AsyncRefactoringBug/blob/after-refactoring/GreetingRequest.cs) and take a look. 
