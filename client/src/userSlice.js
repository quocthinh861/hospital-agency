import {createSlice} from '@reduxjs/toolkit'

export const userSlice = createSlice({
    name: 'user',
    initialState: {
        currentUser: null,
    },
    reducers: {
        setLogIn: (state, action) => {
            state.currentUser = action.payloay;
        },
        setSignOut: (state) => {
            state.currentUser = {}
        }
    }
})

export const {setLogIn, setSignOut} = userSlice.actions
export default userSlice.reducer