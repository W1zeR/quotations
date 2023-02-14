# quotations

docker pull postgres

docker run --name postgres --restart=always -p 25432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=meow -e POSTGRES_DB=quotations -v postgresvolume:/var/lib/postgresql/data -d postgres