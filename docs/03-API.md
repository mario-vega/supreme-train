# POST /tasks

## Request

{
    "title": "Buy milk",
    "description": "go to market",
    "priority": 2
}

## Response

201 Created

{
    "id": "guid",
    "description": "Buy milk"
}

400 Bad request
---

# GET /tasks/{id}

## Response

200 OK

{
    "id":"guid",
    "description":"Buy milk",
    "priority": 2,
    "date": "11/19/2026"
}

404 Not found

{
    "ErrorMessage": "Task with id {id} not found."
}
---

# GET /tasks/today

## Response

200 OK

[
    {
        "id":"guid",
        "description": "Buy milk",
        "priority": 2,
        "date": "11/19/2026"
    },
    {
        "id":"guid",
        "description":"Buy milk",
        "priority": 2,
        "date": "11/19/2026"
    }
]

500 Internal server error

---

# PATCH /tasks/{id}

## Response

200 OK

{
    "id": "guid"
    "description": "Buy milk",
    "priority": 2,
    "done": true
}

400 Bad request
404 Not found
