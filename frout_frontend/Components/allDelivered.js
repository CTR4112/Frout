import React from 'react';
import styled from 'styled-components';

const Container = styled.div`    
    width=100%;
    height: auto;
    color: green;
    background-color: white;
`;

export default function Menu(props) {
    return (
        <>
            <Container>
                <h1 onClick={() => props.setView('home')}>Hooray! All goods delivered! Click here to return to home screen!</h1>
            </Container>
        </>
    );
}