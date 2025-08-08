.PHONY: db-start

db-start:
	docker run --name swin-bite-db \
		-e POSTGRES_PASSWORD=mysecretpassword \
		-p 5432:5432 \
		-d postgres:16-alpine
