import styled from "styled-components";

export const Container = styled.div`
    display: flex;
    margin: 10px 20px 10px 20px;
    height: 100%;
    flex-direction: column;
`;

export const Content = styled.div`
    display: flex;
    flex-direction: column;
    box-sizing: border-box;
    align-items: center;
    justify-content: center;
`;

export const Table = styled.table`
    width: 100%;
    border: 1px solid black;
    margin: 40px;
`

export const Tbody = styled.tbody`
    width: 100%;
    border: 1px solid black;
    height: 40px;
    margin: 40px;
`

export const Control = styled.div`
    display: flex;
    justify-content: flex-end;
    width: 100%;
    margin-top: 10px;
    margin-bottom: 20px;
    /* border: 1px solid black; */
`

export const Button = styled.button`
    margin-left: 5px;
`