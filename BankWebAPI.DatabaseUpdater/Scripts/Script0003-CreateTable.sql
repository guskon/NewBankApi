CREATE TABLE account(
	id serial PRIMARY KEY,
	account_number TEXT NOT NULL,
	creation_date TIMESTAMP NOT NULL,
	account_type int NOT NULL,
	balance decimal NOT NULL,
	client_id INTEGER,
	CONSTRAINT fk_client_id
		FOREIGN KEY (client_id)
			REFERENCES clients (id)
)
CREATE TABLE account_type(
	id serial PRIMARY KEY,
	name TEXT NOT NULL
)