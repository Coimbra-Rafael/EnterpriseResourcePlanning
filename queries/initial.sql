CREATE DATABASE enterprise_resource_planning;

GRANT ALL PRIVILEGES ON DATABASE enterprise_resource_planning TO rafael;


CREATE TABLE customers (
    id_customer UUID NOT NULL PRIMARY KEY, 
    license BYTEA NOT NULL,               
    fantasy_name VARCHAR(160) NOT NULL
	created_at TIMESTAMP DEFAULT NOW(),
);

CREATE INDEX idx_customers ON customers(id_customer);

CREATE TABLE config_customer (
    id_config_customer UUID NOT NULL, 
    id_customer UUID NOT NULL,
 	created_at TIMESTAMP DEFAULT NOW(),  
    updated_at TIMESTAMP DEFAULT NOW()   
    PRIMARY KEY (id_config_customer, id_customer),
    CONSTRAINT fk_customer FOREIGN KEY (id_customer) REFERENCES customers (id_customer)
);


CREATE TABLE enterprise (
    id_enterprise UUID NOT NULL PRIMARY KEY, 
    id_customer UUID NOT NULL,               
    fantasy_name VARCHAR(160) NOT NULL,      
    reason_social VARCHAR(160) NOT NULL,     
    cnpj_cpf VARCHAR(14) NOT NULL,           
    state_registration VARCHAR(9),           
    email VARCHAR(150) NOT NULL,             
    phone VARCHAR(20) NOT NULL,
	created_at TIMESTAMP DEFAULT NOW(),
    CONSTRAINT fk_customer_enterprise FOREIGN KEY (id_customer) REFERENCES customers (id_customer)
);

CREATE INDEX idx_enterprise_customer ON enterprise(id_customer);


CREATE TABLE addresses (
    id_address UUID NOT NULL PRIMARY KEY,  
    street VARCHAR(255) NOT NULL,        
    number VARCHAR(20) NOT NULL,         
    complement VARCHAR(100),             
    neighborhood VARCHAR(100) NOT NULL,  
    city VARCHAR(100) NOT NULL,          
    state VARCHAR(2) NOT NULL,           
    postal_code VARCHAR(8) NOT NULL,     
    country VARCHAR(50) DEFAULT 'Brasil',
    created_at TIMESTAMP DEFAULT NOW(),  
    updated_at TIMESTAMP DEFAULT NOW()   
);

CREATE INDEX idx_addresses ON addresses(id_address);

CREATE TABLE uf (
    id_uf UUID NOT NULL PRIMARY KEY,       
    name VARCHAR(100) NOT NULL,            
    abbreviation CHAR(2) NOT NULL UNIQUE,  
    created_at TIMESTAMP DEFAULT NOW(),    
    updated_at TIMESTAMP DEFAULT NOW()     
);

CREATE TABLE municipalities (
    id_municipality UUID NOT NULL PRIMARY KEY,  
    id_uf UUID NOT NULL,                        
    name VARCHAR(100) NOT NULL,                 
    ibge_code VARCHAR(7) NOT NULL UNIQUE,       
    created_at TIMESTAMP DEFAULT NOW(),         
    updated_at TIMESTAMP DEFAULT NOW(),         
    CONSTRAINT fk_uf FOREIGN KEY (id_uf) REFERENCES uf (id_uf) ON DELETE CASCADE
);

CREATE INDEX idx_municipalities_uf ON municipalities(id_uf);

INSERT INTO uf (id_uf, name, abbreviation) VALUES
(gen_random_uuid(), 'Acre', 'AC'),
(gen_random_uuid(), 'Alagoas', 'AL'),
(gen_random_uuid(), 'Amapá', 'AP'),
(gen_random_uuid(), 'Amazonas', 'AM'),
(gen_random_uuid(), 'Bahia', 'BA'),
(gen_random_uuid(), 'Ceará', 'CE'),
(gen_random_uuid(), 'Distrito Federal', 'DF'),
(gen_random_uuid(), 'Espírito Santo', 'ES'),
(gen_random_uuid(), 'Goiás', 'GO'),
(gen_random_uuid(), 'Maranhão', 'MA'),
(gen_random_uuid(), 'Mato Grosso', 'MT'),
(gen_random_uuid(), 'Mato Grosso do Sul', 'MS'),
(gen_random_uuid(), 'Minas Gerais', 'MG'),
(gen_random_uuid(), 'Pará', 'PA'),
(gen_random_uuid(), 'Paraíba', 'PB'),
(gen_random_uuid(), 'Paraná', 'PR'),
(gen_random_uuid(), 'Pernambuco', 'PE'),
(gen_random_uuid(), 'Piauí', 'PI'),
(gen_random_uuid(), 'Rio de Janeiro', 'RJ'),
(gen_random_uuid(), 'Rio Grande do Norte', 'RN'),
(gen_random_uuid(), 'Rio Grande do Sul', 'RS'),
(gen_random_uuid(), 'Rondônia', 'RO'),
(gen_random_uuid(), 'Roraima', 'RR'),
(gen_random_uuid(), 'Santa Catarina', 'SC'),
(gen_random_uuid(), 'São Paulo', 'SP'),
(gen_random_uuid(), 'Sergipe', 'SE'),
(gen_random_uuid(), 'Tocantins', 'TO');

