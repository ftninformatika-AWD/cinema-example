import React, { useEffect, useState } from 'react';
import CinemaAxios from '../../apis/CinemaAxios';
import { useNavigate } from 'react-router-dom';

const AddScreening = () => {

    var navigate = useNavigate()

    let screeningInit = {
        time: "",
        type: "",
        hall: 0,
        price: 0.00,
        movie: null
    }

    const [screening, setScreening] = useState(screeningInit)
    const [movies, setMovies] = useState([])

    useEffect(() => {
        // TODO: Dobaviti filmove i odluciti na koji nacin iskoristiti je u useEffect
        const getMovies = () => {
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
        }

        getMovies()
    }, [])

    const create = () => {
        let params = {
            scheduledAt: (new Date(screening.time)).toISOString(),
            movieId: screening.movie,
            room: screening.hall,
            screeningType: screening.type,
            ticketPrice: screening.price
        }

        console.log(params);

        CinemaAxios.post('/screenings', params)
            .then(res => {
                console.log(res);
                navigate('/screenings');
            })
            .catch(error => {
                console.log(error);
                alert('Error occured please try again!');
            })
    }

    const valueInputChanged = (e) => {
        let input = e.target;

        let name = input.name;
        let value = input.value;

        let screeningFromState = screening;
        screeningFromState[name] = value;

        setScreening(screeningFromState)
        console.log(screening)
    }

    // TODO: Rukovati prihvatom vrednosti na promenu
    const movieSelectionChanged = (e) => {
        // console.log(e);

        let movieId = e.target.value;

        let screeningFromState = screening;
        screeningFromState.movie = movieId;

        setScreening(screeningFromState);
    }

    // TODO: Omogućiti odabir filma za projekciju
    return (
        <div>
            <h1>Add Screening</h1>

            <label htmlFor="pTime">Time</label>
            <input id="pTime" name="time" type="datetime-local" onChange={(e) => valueInputChanged(e)} /> <br />
            <label htmlFor="pType">Type</label>
            <input id="pType" name="type" onChange={(e) => valueInputChanged(e)} /> <br />
            <label id="pHall">Hall</label>
            <input type="number" id="pHall" name="hall" onChange={(e) => valueInputChanged(e)} /> <br />
            <label htmlFor="pPrice">Price</label>
            <input type="number" step=".01" id="pPrice" name="price" onChange={(e) => valueInputChanged(e)} /> <br />
            <label htmlFor="pMovie">Movies</label>
            <select id="pMovie" onChange={event => movieSelectionChanged(event)}>
                {
                    movies.map((movie) => {
                        return (
                            <option key={movie.id} value={movie.id}>{movie.name}</option>
                        )
                    })
                }
            </select>
            <br />
            <button onClick={ () => { create() }}>Add</button>
        </div>
    )
}

export default AddScreening;