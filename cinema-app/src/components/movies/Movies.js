import React, { useState, useEffect, useCallback } from 'react';
import { useNavigate } from "react-router-dom";
import CinemaAxios from './../../apis/CinemaAxios';

import './../../index.css';
import MovieRow from './MovieRow';

const Movies = () => {

    const [movies, setMovies] = useState([])
    var navigate = useNavigate()

    const getMovies = useCallback(() => {
        CinemaAxios.get('/movies')
            .then(res => {
                 // handle success
                 console.log(res);
                 setMovies(res.data)
            })
            .catch(error => {
                // handle error
                console.log(error);
                alert('Error occured please try again!');
            });
    }, [ ]);

    useEffect(() => {
        getMovies();
    }, []);

    const renderMovies = () => {
        return movies.map((movie, index) => {
            return <MovieRow key={movie.id} movie={movie}></MovieRow>
         })
    }

    function goToAdd() {
        navigate('/movies/add'); 
    }

    return (
        <div>
            <h1>Movies</h1>
            
            <div>
                <button className="button button-navy" onClick={() => goToAdd() }>Add</button>
                <br/>
                
                <table id="movies-table">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Duration (min)</th>
                            <th>Genre</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {renderMovies()}
                    </tbody>                  
                </table>
            </div>
        </div>
    );
}

export default Movies;