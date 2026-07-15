# Functional Features

## RF-001 Create task

User can create a task

Properties:

- Title
- Description
- Date
- Priority

Rules:

- Title is required
- 100 characters max
- Date is required

---

## RF-002

Must be posible to search a task by Id.

---

## RF-003

A search by partial Title coincidence must exist.

Example

GET /tasks?search=home

Should return:

- Homework
- Home repairs

## RF-004

Get a list of all tasks in descendant order.

GET /tasks

## RF-005

Get a list of all tasks added in the day with descendant added order.

GET /tasks/today