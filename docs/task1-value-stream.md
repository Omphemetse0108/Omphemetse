\# Task 1 — Transformation and Value-Stream Plan

\## Student Services API



\### 1. Current-State Value Stream (Work Request → Tested Build)



The Student Services API is currently integrated manually: developers push

directly to `main`, no CI exists, and build/test failures are discovered

late by whoever next picks up the code. This creates a long, unpredictable

lead time from request to tested build.



| # | Stage | Role | Process Time | Wait Time | %C\&A | Bottleneck |

|---|-------|------|--------------|-----------|------|------------|

| 1 | Work request intake | Product Owner | 2 h | 1–3 days | 60% | |

| 2 | Refinement \& acceptance criteria | Team + PO | 4 h | 1 day | 70% | |

| 3 | Development (feature work) | Developer | 2–5 days | — | 75% | |

| 4 | Manual merge to `main` | Developer | 15 min | 2–4 days | 50% | Primary |

| 5 | Build on developer machine | Developer | 5 min | — | 60% | |

| 6 | Tests run locally (if any) | Developer | 10–30 min | — | 55% | |

| 7 | Ad-hoc integration testing | Whoever is free | 1–3 days | 2–5 days | 45% | Critical |

| 8 | Manual regression check | QA (part-time) | 2–4 h | 1–3 days | 50% | |

| 9 | Tested-build hand-off | Team lead | 30 min | 0.5 day | 70% | |



\*\*Calculated baseline metrics\*\*

\- Total lead time: \*\*\~8–18 working days\*\*

\- Total process time: \*\*\~3–6 working days\*\*

\- Flow efficiency: \*\*\~33%\*\*

\- Change failure rate: \*\*\~35%\*\* (failures found after merge)



\### 2. Identified Bottlenecks and Waste



| Bottleneck | Waste Type | Impact |

|------------|------------|--------|

| Manual merges to `main` | Waiting, rework | Conflicts and broken `main` |

| No CI pipeline | Waiting, defects | Failures detected late |

| Ad-hoc integration testing | Waiting, overprocessing | Unpredictable release dates |

| Part-time QA availability | Waiting | 1–3 day queue per build |

| No test coverage signal | Defects | Unknown quality baseline |

| No versioned artefacts | Inventory | Builds cannot be traced to commits |



\### 3. Target-State Value Stream



