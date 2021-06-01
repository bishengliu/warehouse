import React from 'react';
import { Link } from 'react-router-dom';
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import './navbar.css';

const NavBar = ():JSX.Element => (
  <Navbar bg="dark" variant="dark" expand="lg">
    <Navbar.Brand as={Link} to="/" className="brand-padding">
      <i className="fa fa-home" />
      <span>Warehouse</span>
    </Navbar.Brand>
    <Navbar.Toggle aria-controls="app-navbar-nav" />
    <Navbar.Collapse id="app-navbar-nav">
      <Nav className="mr-auto">
        <NavDropdown title="Inventory" id="app-nav-dropdown">
          <NavDropdown.Item as={Link} to="/inventory">
            <i className="fa fa-list" />
            <span> All articles</span>
          </NavDropdown.Item>
          <NavDropdown.Item as={Link} to="/inventory">
            <i className="fa fa-upload" />
            <span> Upload articles</span>
          </NavDropdown.Item>
        </NavDropdown>
        <NavDropdown title="Product" id="app-nav-dropdown">
          <NavDropdown.Item as={Link} to="/product">
            <i className="fa fa-list" />
            <span> All products</span>
          </NavDropdown.Item>
          <NavDropdown.Item as={Link} to="/product">
            <i className="fa fa-upload" />
            <span> Upload products</span>
          </NavDropdown.Item>
        </NavDropdown>
        <Nav.Link as={Link} to="/product">
          <i className="fa fa-th" />
          <span> Stock</span>
        </Nav.Link>
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);

export default NavBar;
