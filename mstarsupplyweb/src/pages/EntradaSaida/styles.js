import styled from "styled-components";

export const Container = styled.div`
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
`

export const Content = styled.div`
    padding: 20px;
    display: flex;
    justify-content: space-between;
    flex-direction: column;
    width: 300px;
`;

export const Label = styled.p`
    margin: 0 0 5px 0;
`

export const Button = styled.button`
    margin-top: 20px;
    height: 40px;
    background: #60c560;
    color: #fff;
    border: none;
`

export const Select = styled.select`
    margin-bottom: 15px;
    height: 25px;
`

export const Input = styled.input`
    margin-bottom: 15px;
    height: 25px;
`

export const RadioField = styled.div`
    text-align: start;
`