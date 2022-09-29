CREATE TABLE addresses(
	id serial PRIMARY KEY,
	house_number INTEGER NOT NULL,
	street VARCHAR(50) NOT NULL,
	city VARCHAR(50) NOT NULL,
	country_code VARCHAR(10) NOT NULL
);
