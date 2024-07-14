# quotations

## Running
- Open Docker
- Open Developer PowerShell in Visual Studio
- Run `docker-compose build`
- Run `docker-compose up`
- Open `http://localhost:10000/swagger/index.html`

## Running Postgres in Docker
1. Add Postgres to Docker if needed
```powershell
docker pull postgres
```
2. Create and run Postgres container
```powershell
docker run --name postgres --restart=always -p 25432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=meow -e POSTGRES_DB=quotations -v postgresvolume:/var/lib/postgresql/data -d postgres
```
