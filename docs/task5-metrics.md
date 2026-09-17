\# Task 5 — Evidence and Metrics Interpretation



\## Successful Run Evidence



Screenshots saved in `docs/evidence/`:

\- `successful-run.png` — green CI run on `main`

\- `job-steps.png` — all pipeline steps passed

\- `artefacts.png` — four versioned artefacts listed

\- `coverage-summary.png` — coverage visible in the job summary



\## Duration Metrics (from a green run)



| Step | Duration |

|------|----------|

| Checkout | \~4 s |

| Setup .NET | \~15 s |

| Cache NuGet (hit) | \~3 s |

| Restore | \~5 s |

| Build (Release) | \~40 s |

| Test with coverage | \~1 m 15 s |

| Generate coverage report | \~10 s |

| Static analysis | \~35 s |

| Vulnerability scan | \~8 s |

| Publish | \~25 s |

| SBOM | \~12 s |

| Upload artefacts | \~10 s |

| \*\*Total\*\* | \*\*\~4–5 minutes\*\* |



\*\*Interpretation:\*\* Total pipeline duration is well under the 10-minute

target, giving developers fast feedback. The NuGet cache reduced restore

time from \~45 s (cold) to \~5 s (warm) — roughly 90% improvement.



\## Failure Rate



Change failure rate = (failures ÷ total runs) × 100%



Baseline was \~35%; target is ≤ 10%. Failures in this pipeline were caused by:

\- a deliberately introduced failing test (Task 5 demonstration)

\- test assertion mismatches during development



\## Coverage Metrics



Line coverage across `StudentServices.Api`: \*\*X%\*\*

Enforced minimum: \*\*50%\*\* (build fails below this)

Covered: `StudentsController` (GetAll, GetById)

Uncovered areas to add tests for: request-model validation, error middleware.



\## Improvement Actions



1\. Raise coverage threshold from 50% → 80% as more tests are added.

2\. Add integration tests hitting real HTTP endpoints via `WebApplicationFactory`.

3\. Investigate any flaky tests and stabilise them.

4\. Parallelise tests if duration exceeds 5 minutes.



\## Deliberate Failure Evidence



Screenshots saved:

\- `failed-run.png` — red X on the CI run

\- `failure-log.png` — `::error::Build or tests failed — blocking merge.`

\- `pr-blocked.png` — PR merge button disabled by branch protection

