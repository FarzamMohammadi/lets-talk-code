# We want our codebase to be...

## Easy to read:

- What does this mean?
    - Good names.
    - Naming conventions.
    - Semantic conditionals:
        - Makes sense when you have 2-3 or more conditions.
            - if(hero.powerLevel > villain.powerLevel && hero.energy > 10 && !villain.monsterMode)
            - if(hero.CanDefeat(villain))
    - Lines of code per method?
        - How much is too much?
            - No definition, just don't get to very high amounts, > 200, 300.
    - How many arguments in a method?
        - How much is too much?
            - No definition, sometimes some parameters make more sense than a class of parameters.
        - Why does a method has too many arguments?
            - Is it doing too much?

## Self explanatory:

- What does this mean?
    - Does this happens when it's easy to read?
        - Yes.
    - Comments should explain why such decision was taken not what the code is doing.
    - Does this have relation with "Follow a pattern"?
        - No.

## Well documented:

- No.
- If there's documentation, update it!!!
- Example:
    - Permissions has not Description on their summary because we have a file with all permissions and descriptions for
      reference.

---------------------------------------------

## Testable:

- Should we push code without test?
    - We should be pushing
    - Integration test to emulate the VR
    - For VD cover cases.

- What does this mean?
    - Every code is testable.
    - Not all code is fun to test.
    - Reducing the amount of "Hard" dependencies.
    - Encapsulation?

What kind of tests should we do and how do we understand them?

- Unit Tests
- Integration Tests
    - https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0#introduction-to-integration-tests
- System Tests - Oana
- E2E Tests - Oana
- Manual Tests - Dennis

Automate checks that can be automated.

- Code compiles
- Tests pass
- Formatted
- Honors code standards

Then our code reviews can focus on checks that can’t be automated:

- Naming
- Readability
- Architecture
- Usability
- Reuse
- Performance
- Accessibility


- Unit Tests:
    - Single unit of code in isolation.
    - Great for quickly test the logic, condition statements and loops.
    - Ideal to test all execution paths of functions.
    - 2 Types:
        - State Based Test
            - Tests the outcomes of the method.
        - Interaction Test
            - Makes sure the method talks to objects properly.
- Integration Tests
    - Covers the gaps of unit tests.
    - Focused on methods that read/write data to an external resource.
        - Example Storage Objects (not repositories):
            - Their only function is to deal directly with external resources, in an integration test we can call
              this method and ensure that the give data is added/deleted.
- System Tests


- Controllers -- Unit Test -> Use case Facade
- Use Cases -- Unit Test -> aggregate/integration orchestration (transaction)
- Repositories -- Unit Test? -> Integration Test?
- Aggregates/Entities -- Unit Test -> system's business logic

## Modular:

- What does this mean?
- What's a module?
- What benefits do we get from modularity?

## Follows a pattern:

- DDD:
    - What can we use from this?
- MVC:
    - This is where we are
- MVVM:
    - Easy to write against (Easily changeable?):
- What does this mean?

## Well organized?

# Let's define a Pet Project to apply those rules

1. Todo List

# Answering Jaime's question

1. How much [Unit] test is enough?
    1. The amount needed to test the complexity of your code.

# What we can do from now on:

1. Every new handler should not depend on InternationalDbContext anymore:
    1. We should create UnitOfWork and Repositories to use on them and reuse in the future.