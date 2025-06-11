import React, { useCallback, useEffect, useState } from 'react';
import CinemaAxios from './../../apis/CinemaAxios';
import { useParams, useNavigate } from 'react-router-dom';

const EditMovie = () => {

    var navigate = useNavigate()
    const routeParams = useParams();
    var movieId = routeParams.id;

    var movie = {
        movieId: -1,
        movieName: '',
        movieDuration: '',
        movieDescription: '',
        movieGenre: -1
    };

    const [updateMovie, setUpdateMovie] = useState(movie);

    const [genres, setGenres] = useState([])

    const getMovieById = useCallback((movieId) => {
        CinemaAxios.get('/movies/' + movieId)
        .then(res => {
            // handle success
            console.log(res);
            setUpdateMovie({ 
                movieId: res.data.id, 
                movieName: res.data.name, 
                movieDuration: res.data.duration,
                movieDescription: res.data.description,
                movieGenre: res.data.genreId
            });
        })
        .catch(error => {
            // handle error
            console.log(error);
            alert('Error occured please try again!');
         });
    }, []);

    useEffect(() => {
        getMovieById(movieId)

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
    }, [ ]);

    const onNameChange = event => {

        setUpdateMovie({ 
            movieName: event.target.value, 
            movieDuration: updateMovie.movieDuration, 
            movieId: updateMovie.movieId,
            movieGenre: updateMovie.movieGenre,
            movieDescription: updateMovie.movieDescription
         });
    }

    const onDurationChange = event => {
        setUpdateMovie({ 
            movieDuration: event.target.value, 
            movieName: updateMovie.movieName, 
            movieId: updateMovie.movieId,
            movieGenre: updateMovie.movieGenre,
            movieDescription: updateMovie.movieDescription
         });
    }

    const onGenreChange = event => {
        setUpdateMovie({ 
            movieId: updateMovie.movieId,
            movieName: updateMovie.movieName, 
            movieDuration: updateMovie.movieDuration, 
            movieGenre: event.target.value,
            movieDescription: updateMovie.movieDescription
        });
    }

    const onDescriptionChange = event => {
        setUpdateMovie({ 
            movieId: updateMovie.movieId,
            movieName: updateMovie.movieName, 
            movieDuration: updateMovie.movieDuration, 
            movieGenre: updateMovie.movieGenre, 
            movieDescription: event.target.value
        });
    }

    const edit = () => {
        var params = {
            'id': updateMovie.movieId,
            'name': updateMovie.movieName,
            'duration': updateMovie.movieDuration,
            'description': updateMovie.movieDescription,
            'genreId': updateMovie.movieGenre
        };

        CinemaAxios.put('/movies/' + updateMovie.movieId, params)
        .then(res => {
            // handle success
            console.log(res);
            alert('Movie was edited successfully!');
            navigate('/movies');
        })
        .catch(error => {
            // handle error
            console.log(error);
            alert('Error occured please try again!');
         });
    }

    return (
        <div>
            <h1>Edit movie</h1>
            <label htmlFor="name">Name</label>
            <input id="name" type="text" value={updateMovie.movieName} 
            onChange={(e) => onNameChange(e)}/><br/>
            <label htmlFor="duration">Duration</label>
            <input id="duration" type="number" value={updateMovie.movieDuration} 
            onChange={(e) => onDurationChange(e)}/>
            <label htmlFor="genre">Genres</label>
            <select id="genre" onChange={event => onGenreChange(event)} value={updateMovie.movieGenre} >
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
            <textarea id="description" onChange={(e) => onDescriptionChange(e)} value={updateMovie.movieDescription} >

            </textarea>
            <button className="button button-navy" onClick={() => edit()}>Edit</button>
        </div>
    );
}

export default EditMovie;