CREATE TABLE account(
	id serial PRIMARY KEY,
	account_number INTEGER NOT NULL,
	creation_date TIMESTAMP NOT NULL,
	account_type VARCHAR(50) NOT NULL,
	balance INTEGER NOT NULL,
	client_id INTEGER,
	CONSTRAINT fk_client_id
		FOREIGN KEY (client_id)
			REFERENCES clients (id)
)