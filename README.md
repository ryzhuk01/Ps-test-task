# Test Task

This is my submission for the full-stack developer test task. The application is a dynamic form submission system built with **Vue 3** and **ASP.NET Core**.

### Architecture
While a simple CRUD approach would suffice for this task scope, I deliberately implemented Clean Architecture and CQRS to demonstrate how I structure scalable enterprise applications and handle separation of concerns because the task requirements explicitly stated: "Consider it as a real-life application. Thus, try to create good architecture and level of abstraction".

- **CQRS**: I used the CQRS pattern (via MediatR) to separate read and write operations.
- **Shared Abstractions**: I included a set of shared abstractions (BuildingBlocks) that i'm using in my own projects. This keeps the core logic clean and consistent.

As requested, the vue application is bundled into a single file with Vite for simple deployment.

I also considered implementing the OperationResult pattern (to avoid using exceptions for flow control) and infinite scroll for the submissions list. However, I decided that the current solution is already sufficiently complex for the scope of this task, so i chose not to over-engineer it further.

Frontend application is located in ClientApp folder. You can run it with the `npm run dev` command.

## Part 2: Handling Large Attachments

### Architecture
Storing large files directly in the database is not efficient. It bloats the database, makes backups slower, and increases memory usage.
Instead, I would use **Object Storage** (AWS S3, Azure Blob Storage).

- **Upload Process**: The frontend would upload files to a dedicated API endpoint. The backend would stream the file directly to the Object Storage (without loading file into RAM) and return a reference ID.
- **Storage**: The database would only store metadata.

### Data Structure
I would introduce a new entity `Attachment` or `File`:
```json
{
  "id": "exId",
  "fileName": "exFileName.pdf",
  "storageKey": "2025/11/20/exFileName.pdf",
  "contentType": "application/pdf",
  "size": 104857600
}
```
The `Submission` document would then have a list of these attachment objects (or just IDs).

### REST API
1. **`POST /api/attachments`**: Accepts `multipart/form-data`. Streams data to storage and returns the `AttachmentId`. This allows the UI to show a progress bar and upload files while the user is still filling out the form.
2. **`POST /api/submissions`**: The main submission endpoint would now accept a list of `attachmentIds` along with the other form fields.
3. **`GET /api/attachments/{id}`**: Validates user access and streams the file from storage to the response (or generates a temporary pre-signed URL for direct download).

I would also implement a Background Job that runs periodically. It would delete files from the Object Storage that are older than a certain threshold and are not linked to any `Submission` in the database.
