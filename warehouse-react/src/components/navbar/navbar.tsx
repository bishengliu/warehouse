import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import './navbar.css';

const NavBar = () => 
    <Navbar bg="dark" variant="dark" expand="lg">
        <Navbar.Brand as={Link} to="/" className="brand-padding">Warehouse</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
                <NavDropdown title="Inventory" id="basic-nav-dropdown">
                    <NavDropdown.Item as={Link} to="/inventory">All articles</NavDropdown.Item>
                    <NavDropdown.Item as={Link} to="/inventory">Upload articles</NavDropdown.Item>
                </NavDropdown>
                <NavDropdown title="Product" id="basic-nav-dropdown">
                    <NavDropdown.Item as={Link} to="/product">All products</NavDropdown.Item>
                    <NavDropdown.Item as={Link} to="/product">Upload products</NavDropdown.Item>
                </NavDropdown>
                <Nav.Link as={Link} to="/product">Stock</Nav.Link>
            </Nav>
        </Navbar.Collapse>
    </Navbar>

export default NavBar;