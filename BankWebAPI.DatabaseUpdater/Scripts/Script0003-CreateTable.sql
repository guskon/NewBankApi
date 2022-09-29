CREATE TABLE account(
	id serial PRIMARY KEY,
	account_number TEXT NOT NULL,
	creation_date TIMESTAMP NOT NULL,
	account_type VARCHAR(50) NOT NULL,
	balance decimal NOT NULL,
	client_id INTEGER,
	CONSTRAINT fk_client_id
		FOREIGN KEY (client_id)
			REFERENCES clients (id)
)