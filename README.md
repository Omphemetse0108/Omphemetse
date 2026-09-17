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