# Pyramid Challenge

The deliverable of this project could be the cli executable `PyramidChallenge.Cli` or the class library `PyramidChallenge`.

### Usage of the Cli tool

```
PyramidChallenge.exe -i input-file-path
```

### General Sesign

The interface that solves the pyramid is `PyramidChallenge.IPyramidSolver` implemented by `PyramidChallenge.PyramidSolver`. I didn't use a complex structure of libraries just for simplicity. The pyramid is represented by the interface `PyramidChallenge.INode` which has a `Left` (number below) and `Right` (number below and right).

The following 3 steps are performed to solve a pyramid:

- Parsing the input, interface `IInputParser`
- Finding all possible paths, interface `IPathFinder`
- Picking the path with the maximun sum, same interface

Those could be internal implementations or even be in separate libraries, but I exposed in the same library so I can easily test them.

The interface `IPyramidSolver` expects a stream as input, so it could be a string, file, etc. Even though a valid input should only be numbers, I also included encoding.

I tried to test each component extensively and seperately. You can find all the tests in `test\PyramidChallenge.Test`. I decided not to generate larger random pyramids for testing, because after trying I saw that it was an overkill and didn't give any extra value.

### Conventions

- The numbers are integers
- If two or more paths have the same sum, I pick the first one
- I didn't included any logging since it wasn't requested

### Nuget packages used

- CommandLineParser
- Unity
