import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Main from './pages/Main';
import EntradaSaidaForm from './pages/EntradaSaida';
import Mercadoria from './pages/Mercadoria';
import Fabricante from './pages/Fabricante';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
            <Routes>
                <Route Component={ Main } path="/" exact />
                <Route Component={ EntradaSaidaForm } path="/entrada-saida" />
                <Route Component={ Mercadoria } path="/mercadoria" />
                <Route Component={ Fabricante } path="/fabricante" />
            </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
