# CSharpMenagerie

[![MIT License](https://badges.frapsoft.com/os/mit/mit.svg?v=103)](https://opensource.org/licenses/mit-license.php)

👓 A collection of small projects, experiments, patterns, and useful snippets for exploring .NET and C#.

## About

CSharpMenagerie is a practical playground for technologies and techniques across the .NET ecosystem. Each directory contains focused examples covering areas such as web APIs, cloud services, concurrency, databases, messaging, performance, security, and testing.

The examples are intended for learning and reference rather than as a production-ready framework. Individual projects may use different target frameworks and dependencies; consult the project directory before running an example.

## Repository layout

| Directory | Topics |
| --- | --- |
| [`API`](API/) | ASP.NET Core APIs, throttling, background worker queues, GraphQL, MVC filters, REST patterns, and controller configuration |
| [`Cloud`](Cloud/) | AWS and Azure integrations and cloud-oriented examples |
| [`Concurrency`](Concurrency/) | Threads, synchronization, parallel work, and concurrent programming |
| [`Containers`](Containers/) | Docker and container-related examples |
| [`Core`](Core/) | ASP.NET Core startup tasks, background services, tracing, middleware, exception handling, security headers, user secrets, and runtime code generation |
| [`Database`](Database/) | Entity Framework and database access examples |
| [`Experiments`](Experiments/) | Small proofs of concept and exploratory samples |
| [`Functional`](Functional/) | Functional programming ideas and C# patterns |
| [`LINQ`](LINQ/) | LINQ techniques, including chunks and join examples |
| [`MessageBrokers`](MessageBrokers/) | RabbitMQ, Kafka, reliable producers, and in-process job queues |
| [`Microservices`](Microservices/) | Distributed application and microservice patterns |
| [`Networking`](Networking/) | HTTP, sockets, and networking examples |
| [`Performance`](Performance/) | Benchmarks and performance-focused experiments |
| [`Reference`](Reference/) | Reference material and reusable snippets |
| [`Security`](Security/) | Security examples and defensive coding patterns |
| [`Testing`](Testing/) | Unit testing, test organization, and testing techniques |

## Highlights

Some notable areas of the collection include:

- **ASP.NET Core APIs** — RESTful job workflows, GraphQL, API throttling, MVC filters, background worker queues, and non-production endpoints
- **Web application infrastructure** — middleware, global exception handling, distributed tracing, startup tasks, metrics, security headers, and user secrets
- **Messaging** — RabbitMQ, Kafka sandbox projects, reliable Kafka producers, and custom in-process job queues
- **Data and LINQ** — Entity Framework examples plus chunking and join techniques
- **Cloud** — AWS and Azure experiments
- **Reliability and operations** — background services, Docker containers, diagnostics, and distributed systems patterns

## Getting started

Each example is generally self-contained and may require different SDKs, runtime services, packages, or environment variables.

1. Clone the repository:

   ```bash
git clone https://github.com/Jac21/CSharpMenagerie.git
cd CSharpMenagerie
```

2. Choose an example directory:

   ```bash
cd Core/DotNetCoreWebApiBestPractices
```

3. Review the project's README and solution/project files, then restore and run it:

   ```bash
dotnet restore
dotnet run
```

If you are opening a solution in Visual Studio or another IDE, select the relevant `.sln`, `.csproj`, or `.fsproj` file for the example you want to explore.

## Contributing

Contributions, fixes, and additional examples are welcome. When adding a project:

- Keep the sample focused on one concept or scenario
- Place it in the most appropriate top-level category
- Include a short README explaining the purpose and prerequisites
- Add clear configuration instructions for secrets or external services
- Avoid committing credentials or environment-specific configuration

Please open an issue or submit a pull request for discussion before making broad structural changes.

## License

This project is licensed under the [MIT License](LICENSE.md).
