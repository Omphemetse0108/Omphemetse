\# Contributing to Student Services API



\## Branch Strategy



| Branch | Purpose | Lifetime |

|--------|---------|----------|

| `main` | Always deployable; protected | Permanent |

| `feature/<issue-id>-<slug>` | New features | < 2 days |

| `fix/<issue-id>-<slug>` | Bug fixes | < 1 day |

| `hotfix/<slug>` | Emergency production fixes | < 4 hours |



`main` is protected: direct pushes are blocked, one approval is required, and

all CI status checks must pass before merging.



\## Workflow



1\. Pick or create a GitHub Issue.

2\. `git checkout -b feature/<issue-id>-<short-description>`

3\. Commit using Conventional Commits.

4\. Push and open a PR against `main` using the template.

5\. Ensure CI is green and one reviewer approves.

6\. Squash-merge; delete the branch.



\## Commit Conventions



| Prefix | Meaning |

|--------|---------|

| `feat:` | New feature |

| `fix:` | Bug fix |

| `docs:` | Documentation |

| `ci:` | CI configuration |

| `test:` | Test-only changes |

| `chore:` | Maintenance |



Always reference the issue: `feat(api): add /version endpoint (#3)`



\## Local Checks Before Pushing



```bash

dotnet restore

dotnet build --configuration Release

dotnet test

