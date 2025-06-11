import { useNavigate } from "react-router-dom";
import CinemaAxios from "../../apis/CinemaAxios";


const ScreeningRow = (props) => {

    var navigate = useNavigate()

    const goToEdit = (screening) => {
        props.editCallback(screening);
        navigate('/screenings/edit');
    }

    const deleteScreening = (screeningId) => {
        CinemaAxios.delete('/screenings/' + screeningId)
        .then(res => {
            alert('Screening was deleted successfully!');
            window.location.reload();
        })
        .catch(error => {
            console.log(error);
            alert('Error occured please try again!');
         });
    }

    const formatDate = (date) => {
        return new Date(date).toLocaleString();
    }

    return (
        <tr>
           <td>{props.screening.movie.name}</td>
           <td>{formatDate(props.screening.scheduledAt)}</td>
           <td>{props.screening.screeningType}</td>
           <td>{props.screening.room}</td>
           <td>{props.screening.ticketPrice}</td>
           <td><button className="button button-navy" onClick={() => goToEdit(props.screening)}>Edit</button></td>
           <td><button className="button button-navy" onClick={() => deleteScreening(props.screening.id)}>Delete</button></td>
        </tr>
     )
}

export default ScreeningRow;