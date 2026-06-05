# Project Context

- **Owner:** Morpheus
- **Project:** ASP.NET Core site for essays and content with a planned gated book download flow
- **Stack:** ASP.NET Core Razor Pages on .NET 10 with C#, Markdown content, MailKit
- **Created:** 2026-06-04T19:11:30.363-04:00

## Learnings

- The feature needs both contact capture validation and download authorization/file-delivery coverage.

### 2026-06-05 — Build/Test/Lint Commands Verification
- **Status:** Documented and merged to decisions.md (2026-06-05T15:52:08Z UTC)
- **Build verification:** ✅ `dotnet build` confirmed (also explicit form: `dotnet build SimplicityFirst/SimplicityFirst.csproj --configuration Release`)
- **Publish verification:** ✅ `dotnet publish SimplicityFirst/SimplicityFirst.csproj -c Release -o ./publish`
- **Test status:** ❌ No test framework configured (xUnit/NUnit/MSTest not present; test projects absent)
- **Lint status:** ✅ `dotnet format` available; no `.editorconfig` or style rules defined
- **Role:** Validated Neo's copilot-instructions draft against actual project state; provided feedback rejecting generic ASP.NET content; supplied verified commands for Scribe to reference
- **Outcome:** Decision captured and ready for copilot-instructions.md reference when needed
