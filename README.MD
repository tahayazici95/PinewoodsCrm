# Pinewoods CRM

Hi, this is a sample customer CRM solution with 2 projects, one UI and one API.

**Prerequisites:**

The .NET 8 SDK, the .NET CLI and a version of SQL Server need to be installed to run the scripts below.

To build, in PowerShell, `cd` into the solution's root folder and run `.\build.bat`.

To run the tests, from the same folder, run `.\test.bat`.
(At the moment, the test projects are empty. I plan to spend an hour to add proper unit tests)

To start, run `.\run.bat`.

## Notes:

I must admit, I gave some wrong answers to the first technical questions as I still Google a lot of this information.
So, after Googling for 2 minutes, I wrote the correct answers below :)

### The `new` keyword:

When used as a declaration modifier, the `new` keyword explicitly hides a member that is inherited from a base class.
When you hide an inherited member, the derived version of the member replcaes the base class version.

### `throw ex` vs `throw`:

`throw ex` resets the stack trace (so your erros would appear to originate from `HandleException`).

`throw` doesn't - the original offender would be preserved.
