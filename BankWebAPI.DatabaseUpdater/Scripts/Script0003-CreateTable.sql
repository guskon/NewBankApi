CREATE TABLE account_type(
	id serial PRIMARY KEY,
	account_type VARCHAR(50) NOT NULL
);
CREATE TABLE account(
	id serial PRIMARY KEY,
	account_number VARCHAR(50) NOT NULL,
	creation_date TIMESTAMP NOT NULL,
	account_type int NOT NULL,
		CONSTRAINT fk_account_type
			FOREIGN KEY (account_type)
				REFERENCES account_type (id),
	balance decimal NOT NULL,
	client_id INTEGER,
		CONSTRAINT fk_client_id
			FOREIGN KEY (client_id)
				REFERENCES clients (id)
);
