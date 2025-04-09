CREATE DATABASE IF NOT EXISTS pedidosdb;
USE pedidosdb;

CREATE TABLE IF NOT EXISTS produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    tipo ENUM('prato', 'bebida') NOT NULL,
    preco DECIMAL(10,2) NOT NULL
);
CREATE TABLE IF NOT EXISTS pedidos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome_solicitante VARCHAR(100) NOT NULL,
    mesa INT NOT NULL,
    status VARCHAR(50) NOT NULL DEFAULT 'Em preparo'
);
CREATE TABLE IF NOT EXISTS pedido_itens (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pedido_id INT NOT NULL,
    produto_id INT NOT NULL,
    quantidade INT NOT NULL,
    FOREIGN KEY (pedido_id) REFERENCES pedidos(id),
    FOREIGN KEY (produto_id) REFERENCES produtos(id)
);
CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100),
    email VARCHAR(100) UNIQUE,
    senha VARCHAR(255)
);
INSERT INTO produtos (nome, tipo, preco) VALUES 
('Hambúrguer', 'prato', 25.00),
('Pizza Margherita', 'prato', 30.00),
('Refrigerante', 'bebida', 6.00),
('Suco Natural', 'bebida', 8.50);
