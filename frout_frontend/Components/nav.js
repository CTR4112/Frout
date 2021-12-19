import React from "react";
import { Navbar, Nav, NavDropdown, Container, } from "react-bootstrap";

export default function Nav(props) {
    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand href="#home">
                    <img
                        src={require('/images/logo.svg')}
                        width="30"
                        height="30"
                        className="d-inline-block align-top"
                        alt="Frout Logo"
                    />
                </Navbar.Brand>

                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="#home" onClick={() => props.setView("home")}>Home</Nav.Link>
                        <Nav.Link href="#map" onClick={() => props.setView("map")}> Map</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar >
    );
}