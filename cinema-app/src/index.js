import React, { useState } from 'react';
import { createRoot } from 'react-dom/client';
import { Route, Link, BrowserRouter as Router, Routes } from 'react-router-dom';
import Home from './components/Home';
import AddMovie from './components/movies/AddMovie';
import EditMovie from './components/movies/EditMovie';
import Movies from './components/movies/Movies';
import Screenings from './components/screenings/Screenings';
import AddScreening from './components/screenings/AddScreening';
import NotFound from './components/NotFound';
import EditScreening from './components/screenings/EditScreening';

const App = () => {

    const [selectedScreening, setSelectedScreening] = useState({})

    return (
        <div>
            <Router>
                <ul>
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    <li>
                        <Link to="/movies">Movies</Link>
                    </li>
                    <li>
                        <Link to="/screenings">Screenings</Link>
                    </li>
                </ul>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/movies" element={<Movies/>} />
                    <Route path="/movies/add" element={<AddMovie />} />
                    <Route path="/movies/edit/:id" element={<EditMovie />} />
                    <Route path="/screenings" element={<Screenings callback={(screening)=>setSelectedScreening(screening)} />} />
                    <Route path="/screenings/add" element={<AddScreening />} />
                    <Route path="/screenings/edit" element={<EditScreening selectedScreening={selectedScreening}/>} />
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </Router>
        </div>
    );
};


const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
    <App />,
);
