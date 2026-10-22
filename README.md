# Student Services API

A small ASP.NET Core Web API that serves student information. This repository
demonstrates a full DevOps workflow: value-stream planning, source-control
collaboration and a continuous-integration pipeline with quality gates.

## Endpoints

| Method | Path | Description |
|--------|------|-------------|
| GET | `/` | Service banner |
| GET | `/health` | Health check |
| GET | `/api/students` | List all students |
| GET | `/api/students/{id}` | Get a single student |

## Repository Layout

- `src/StudentServices.Api/` — API source code
- `tests/StudentServices.Api.Tests/` — xUnit tests
- `.github/workflows/ci.yml` — CI pipeline
- `docs/` — value-stream plan, metrics, troubleshooting, references

## Continuous Integration

Every push and pull request to `main` triggers CI:

1. Restore dependencies (with NuGet caching)
2. Build in Release configuration
3. Run tests with coverage
4. Enforce minimum coverage threshold
5. Static analysis with warnings as errors
6. Vulnerability scan
7. Generate SBOM
8. Publish versioned artefacts

## Local Development

```bash
dotnet restore
dotnet build --configuration Release
dotnet test
dotnet run --project src/StudentServices.Api



---

## Runbook & Verification (Task 5)

### 1. Verification & Failure Gate
- **Smoke Tests:** The pipeline automatically runs a smoke test by hitting the `/health` endpoint. 
- **Failure Gate:** If the smoke test fails (does not return HTTP 200), the `test` stage fails, and the `release` stage will **not** execute. This prevents broken code from being released.

### 2. Rollback Procedure
If a release has a critical bug, we can roll back using Git tags:
1. Go to the **Releases** page on the right side of the repository.
2. Find the previous stable version (e.g., `v1.0.0`).
3. Click **Edit** (pencil icon) on that old release.
4. Click **Re-release** (or update the tag to point to a new commit). This redeploys the known-good version.
*(Alternative: Re-run the GitHub Actions workflow manually using the old tag).*

### 3. Local Cleanup Guidance
To clean up your local Docker environment after testing:
- Stop containers and remove volumes: `docker compose down -v`
- Remove unused images: `docker system prune -f`

### 4. Limitations
- **Database Migrations:** Rolling back the Docker image does not automatically roll back database schema changes.
- **Secrets:** Environment secrets are injected at runtime; they are not rotated automatically by the pipeline.

### 5. Harvard References
- GitHub (2026) *Managing environments for deployment*. Available at: https://docs.github.com/en/actions/deployment/targeting-different-environments/using-environments-for-deployment (Accessed: 22 October 2026).
- Docker (2026) *Docker Compose overview*. Available at: https://docs.docker.com/compose/ (Accessed: 22 October 2026). 
