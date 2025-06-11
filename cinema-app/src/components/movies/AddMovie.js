import React, { useEffect, useState } from 'react';
import { useNavigate } from "react-router-dom";
import CinemaAxios from './../../apis/CinemaAxios';

const AddMovie = () => {

    var movie = {
        name: '',
        duration: 0,
        genre: -1,
        description: ''
    };

    const [newMovie, setNewMovie] = useState(movie);
    const [genres, setGenres] = useState([])

    var navigate = useNavigate();

    useEffect(() => {
        const getGenres = () => {
            CinemaAxios.get('/genres')
                .then(res => {
                    // handle success
                    console.log(res);
                    setGenres(res.data)
                })
                .catch(error => {
                    // handle error
                    console.log(error);
                    alert('Error occured please try again!');
                });
        }

        getGenres()
    }, [])

    const create = () => {
        var params = {
            'name': newMovie.name,
            'duration': newMovie.duration,
            'genreId': newMovie.genre,
            'description': newMovie.description
        };

        console.log(params);

        CinemaAxios.post('/movies', params)
        .then(res => {
            // handle success
            console.log(res);
           
            alert('Movie was added successfully!');
            navigate('/movies'); 
        })
        .catch(error => {
            // handle error
            console.log(error);
            alert('Error occured please try again!');
         });
    }

    const onNameChange = event => {

        setNewMovie({ 
            name: event.target.value, 
            duration: newMovie.duration, 
            genre: newMovie.genre,
            description: newMovie.description
        });
    }

    const onDurationChange = event => {
        setNewMovie({ 
            name: newMovie.name, 
            duration: event.target.value, 
            genre: newMovie.genre,
            description: newMovie.description
        });
    }

    const onGenreChange = event => {
        setNewMovie({ 
            name: newMovie.name, 
            duration: newMovie.duration, 
            genre: event.target.value,
            description: newMovie.description
        });
    }

    const onDescriptionChange = event => {
        setNewMovie({ 
            name: newMovie.name, 
            duration: newMovie.duration, 
            genre: newMovie.genre, 
            description: event.target.value
        });
    }

    return (
        <div>
            <h1>Add new movie</h1>
            <label htmlFor="name">Name</label>
            <input id="name" type="text" onChange={(e) => onNameChange(e)}/><br/>
            <label htmlFor="duration">Duration</label>
            <input id="duration" type="number" onChange={(e) => onDurationChange(e)}/><br/>
            <label htmlFor="genre">Genres</label>
            <select id="genre" onChange={event => onGenreChange(event)}>
                {
                    genres.map((genre) => {
                        console.log(genre)
                        return (
                            <option key={genre.id} value={genre.id}>{genre.name}</option>
                        )
                    })
                }
            </select>
            <br/>
            <label htmlFor="description">Description</label>
            <textarea id="description" onChange={(e) => onDescriptionChange(e)}>

            </textarea>
            <button className="button button-navy" onClick={create}>Add</button>
        </div>
    );
}

export default AddMovie;