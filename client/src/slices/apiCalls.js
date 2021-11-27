import {loginStart, loginSuccess, loginFailure} from './userSlice'
import axios from 'axios'

export const login = async (dispatch, user) => {
    dispatch(loginStart())
    try {
        const res = await axios.post('http://localhost:3071/api/manager/login', user);
        console.log(res.data)
        if(res.data == null ||
            res.data == undefined ||
            res.data.length == 0)
            dispatch(loginFailure())
        else 
            dispatch(loginSuccess(res.data))
    } catch(err){
        dispatch(loginFailure())
    }
}