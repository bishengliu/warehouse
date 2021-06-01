import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import './navbar.css';

const NavBar = () => 
    <Navbar bg="dark" variant="dark" expand="lg">
        <Navbar.Brand as={Link} to="/" className="brand-padding"><span className="fa fa-home"></span>  Warehouse</Navbar.Brand>
        <Navbar.Toggle aria-controls="app-navbar-nav" />
        <Navbar.Collapse id="app-navbar-nav">
            <Nav className="mr-auto">
                <NavDropdown title="Inventory" id="app-nav-dropdown">
                    <NavDropdown.Item as={Link} to="/inventory"><i className="fa fa-list"></i> All articles</NavDropdown.Item>
                    <NavDropdown.Item as={Link} to="/inventory"><i className="fa fa-upload"></i> Upload articles</NavDropdown.Item>
                </NavDropdown>
                <NavDropdown title="Product" id="app-nav-dropdown">
                    <NavDropdown.Item as={Link} to="/product"><i className="fa fa-list"></i> All products</NavDropdown.Item>
                    <NavDropdown.Item as={Link} to="/product"><i className="fa fa-upload"></i> Upload products</NavDropdown.Item>
                </NavDropdown>
                <Nav.Link as={Link} to="/product"><i className="fa fa-th"></i> Stock</Nav.Link>
            </Nav>
        </Navbar.Collapse>
    </Navbar>

export default NavBar;