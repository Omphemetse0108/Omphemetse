# Release Plan

## 1. Branching and Versioning
We use the `main` branch as our single source of truth. All changes arrive via Pull Requests that must pass CI. Releases are numbered using Semantic Versioning (SemVer, e.g., v1.0.0, v1.1.0) and triggered by pushing a tag starting with `v`.

## 2. Test and Release Stages
**Test Stage:** Automatically runs when a tag is pushed. It builds the Docker image and runs a smoke test calling the `/health` endpoint. No human approval needed.
**Release Stage:** Only runs if the Test Stage passes. It requires manual approval before proceeding to publish the release.

## 3. Artefact Promotion
The Test Stage builds the Docker image once and uploads it as an artefact (`image.tar`). The Release Stage downloads and reuses this exact same artefact, ensuring that what was tested is exactly what is released.

## 4. GitHub Environment Approvals
We use two GitHub Environments: `test` and `release`. The `release` environment is configured with "Required reviewers", so the workflow pauses and waits for a human to approve. It also has "Prevent self-review" enabled.

## 5. Release Notes
Release notes are automatically generated using the `generate_release_notes: true` setting when the GitHub Release is created, pulling in merged PRs and commit history.

## 6. Success Criteria
A release is successful when:
1. The smoke test returns HTTP 200.
2. A reviewer approves the release stage.
3. The GitHub Release is published with the generated notes and the `image.tar` artefact attached.

## 7. Separation of Duties
By using "Required reviewers" and "Prevent self-review" on the release environment, we ensure the developer who triggers the workflow cannot approve their own release. The approval must be done by a different team member.
