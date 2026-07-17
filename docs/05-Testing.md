# Conventions

The unit testing project should be created at inside the folder supreme-train\src and use Api.UnitTests as project name

Every endpoing must contain unit tests.

All validations should be tested.

Do not use a real database.

Use Moq.

Naming:

Method_Should_Result_When_Condition

Example

CreateTask_Should_ReturnBadRequest_When_DescriptionIsEmpty

Minimum coverage

80%