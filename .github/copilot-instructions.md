# Copilot Coding Agent — Project Instructions

Welcome to **Simplicity First**, an ASP.NET Core Razor Pages site for essays and gated book download. This guide helps you work effectively in this repository while respecting its philosophy and architecture.

---

## Quick Start

### Build & Run
```bash
# Restore and build
dotnet build

# Run the application (starts on https://localhost:5001)
dotnet run --project SimplicityFirst/SimplicityFirst.csproj

# Watch mode for development
dotnet watch --project SimplicityFirst/SimplicityFirst.csproj run
```

---

## Architecture

This project follows the **Simplicity-First Manifesto** (see `SimplicityFirst/manifesto.md`). Core principle: **A system is simple if a tired, stressed, unfamiliar engineer can understand it well enough to fix it quickly.**

**Presentation Layer:** Razor Pages (stateless handlers, `OnGet`/`OnPost` async)
- Form validation via DataAnnotations (email address, required fields)
- HTMX for lightweight modal/partial interactions
- Markdown essays in `Essays/` → rendered with Markdig

**Services Layer:** Interface-based abstraction
- `ISubscriberStore` — CSV-backed (`Data/subscribers.csv`, thread-safe via `SemaphoreSlim`)
- `IEmailSender` — MailKit SMTP abstraction (config-driven)
- Both registered in `Program.cs` DI container (Singleton/Transient as appropriate)

**Data Layer (Current):** CSV (`Email`, `SubscribedAtUtc`)
**Data Layer (Planned):** SQLite (EF Core) for gated book contacts—separate `IContactStore` interface (name, email, company) with capture-then-reveal download gating.

See `.squad/decisions.md` for architectural decisions including Gated Book Download strategy.

---

## Key Conventions

### Naming & Code Style
- **C# 14 / .NET 10** with nullable reference types enabled
- **Interfaces:** `IPrefixed` (e.g., `ISubscriberStore`)
- **Page handlers:** `OnGet`, `OnPost`, `OnPostAsync` (async for I/O)
- **View structure:** `.cshtml` markup, `.cshtml.cs` code-behind
- **Partials:** `_NamePrefix.cshtml` (e.g., `_SubscribeResult.cshtml`)
- **No magic:** Prioritize readability over DRY. Minimal comments—only clarify intent when code alone cannot.

### Dependency Injection (DI) Pattern
- Register in `Program.cs`: `builder.Services.AddSingleton<IInterface, Implementation>();`
- Inject via constructor: `public class Model(IInterface dependency) : PageModel`
- Configuration via Options pattern: `builder.Configuration.GetSection("SectionName")`

### Form Validation (DataAnnotations)
```csharp
[BindProperty]
[EmailAddress]
[Required]
public string Email { get; set; }

public async Task<IActionResult> OnPostAsync()
{
    if (!ModelState.IsValid)
        return Page(); // Re-render with validation errors
    // Process...
}
```

### Configuration
- **Development:** `appsettings.Development.json` (git-ignored)
- **Production:** `appsettings.json` (safe defaults)
- Email config under `EmailSettings` section (injected as `IOptions<EmailSettings>`)

---

## Testing & Linting

- **Testing:** No unit test project yet. Manual testing is the current approach. Ensure changes satisfy the 2 AM Test: could a stressed engineer debug and fix this quickly?
- **Linting:** No formal linting tool configured. Code review should evaluate readability, clarity, and adherence to conventions above.

---

## Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| MailKit | 4.15.1 | SMTP email sending |
| Markdig | 1.1.1 | Markdown rendering |
| (Planned) Microsoft.EntityFrameworkCore.Sqlite | Latest | SQLite for gated contact capture |

---

## Squad & Team Context

This project uses **Squad**, an AI team framework. For Copilot agents:

1. Check `.squad/routing.md` for work assignment rules.
2. Use branch convention: `squad/{issue-number}-{kebab-case-slug}` (e.g., `squad/42-add-contact-store`)
3. Reference issues in PR descriptions: `Closes #{number}`. Mention squad review if needed.
4. Document architectural decisions to `.squad/decisions/inbox/copilot-{slug}.md` for the Scribe to merge.
5. For agent-specific style, read `.squad/agents/{member}/charter.md`.

---

## Philosophy Checklist

Before committing, ask yourself:

- [ ] **2 AM Test:** Could I debug this at 2 AM under stress?
- [ ] **Half-Rule:** Did I build the minimum needed to ship and learn?
- [ ] **Primary Path First:** Is the happy path fast and clear?
- [ ] **Clarity > Cleverness:** Is this easy to read, even if not elegant?
- [ ] **Operability:** Can someone run this without extensive docs or tribal knowledge?

If you answer "no" to any of these, reconsider before shipping.

---

## Git Workflow

1. **Branch:** Use squad convention: `squad/{issue-number}-{slug}`
2. **Commit:** Atomic, descriptive messages. Include `Co-authored-by: Copilot` trailer if you're an agent.
3. **PR:** Reference issue (`Closes #{number}`), mention squad review if needed
4. **Review:** Respect 2 AM Test — is this easy to understand and debug under stress?

---

## Resources

- **Project:** https://github.com/cwoodruff/simplicity-first-dev
- **Manifesto:** `SimplicityFirst/manifesto.md`
- **Team Charter:** `.squad/agents/{member}/charter.md`
- **Decisions:** `.squad/decisions.md`
- **ASP.NET Docs:** https://learn.microsoft.com/en-us/aspnet/core/
- **EF Core Docs:** https://learn.microsoft.com/en-us/ef/core/
