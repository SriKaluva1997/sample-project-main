# LendingPad Sample Project – Task TT-1

This repository contains my implementation of the technical assignment provided by LendingPad. The solution is based on the `LendingPad-SampleProject` template and includes fixes for backend issues as well as implementation of new entities and APIs using in-memory storage instead of RavenDB.

---

##  Environment Setup

1. **RavenDB** 
2. **Postman** – Collection file included for testing APIs
3. **Project Source** – All work done on branch `TT-1` from `master`

---

## Task 1 – API Debug & Fix


### Objective:
- Identified backend issues from 4 provided Postman requests
- Fixed controller/service logic accordingly
- Ensured that each request works as expected.

## Task 2 – New Entity API Creation

### a) Created New Entities (OOP-based)
- `Product` and `Order` classes with private fields, property accessors, and validation logic
- Both inherit from `IdObject` to support consistent entity ID tracking

### b) Created Web API Methods
Controllers implemented for both entities:
- `ProductController`
- `OrderController`

Each supports:
- **Create** → `POST /{entity}/{id}/create`
- **Update** → `POST /{entity}/{id}/update`
- **Delete** → `DELETE /{entity}/{id}/delete`
- **Get by ID** → `GET /{entity}/{id}`
- **Get List (filtered)** → `GET /{entity}/list[?filter]`

### c) Created Web API Requests in Postman

##Exported the Postman collection and updated the file in the repository as  LendingPad-SampleProject.postman_collection_SriKaluva.json
