# POST /tasks

## Request

{
    "title": "Comprar leche",
    "description": "Ir al supermercado",
    "priority": 2
}

## Response

201 Created

{
    "id": "guid",
    "title": "Comprar leche"
}

---

# GET /tasks/{id}

## Response

200 OK

{
    "id":"guid",
    "title":"Comprar leche",
    "priority":2
}