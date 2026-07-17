# Functional Features

## RF-001 Add task

User can add a new task

Properties:

- Description
- Priority

Rules:

- Description is required
- 100 characters max
- Date is required

---

## RF-002

Get a list of all tasks added in the current day using a descendant added order.

GET /tasks/today

---

## RF-003

Must be posible to search a task by Id.

---

## RF-004

Get a list of all tasks in descendant order.

GET /tasks

---

## RF-005

A search by partial Title coincidence must exist.

Example

GET /tasks?search=home

Should return:

- Homework
- Home repairs



