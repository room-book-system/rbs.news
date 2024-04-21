# RBS.News

This is the RBS.News project, a part of the Room Book System. The service is built using .NET, tailored to handle and disseminate news updates, events, and other relevant information directly on the associated site.



## Prerequisites

- .NET 8
- Docker

## Getting Started

1. Clone the repository:

```bash
git clone git@github.com:room-book-system/rbs.news.git
```

2. Switch to the project directory:

```bash
cd rbs.news
```
3. Build the project:

```bash
dotnet build
```

## Running the Application

1. Start MongoDB using Docker Compose:

```bash
docker-compose up -d
```

2. Run the application:

```bash
dotnet run --project RBS.News.Api/RBS.News.Api.csproj
```


## License
This project is licensed under the Apache-2.0 License - see the [LICENSE](https://github.com/room-book-system/rbs.news/blob/main/LICENSE) file for details.
