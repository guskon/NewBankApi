CREATE TABLE clients(
	id serial PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	personal_code VARCHAR(50) NOT NULL,
	address_id INTEGER,
	CONSTRAINT fk_address_id
		FOREIGN KEY (address_id)
			REFERENCES addresses (id)
);