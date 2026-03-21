import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Register = () => {
    const [user, setUser] = useState({ email: '', password: '', userName: '' });
    const navigate = useNavigate();

    const handleRegister = async (e) => {
        e.preventDefault();
        try {
            await axios.post('https://localhost:7123/api/Auth/register', user);
            alert("Đăng ký thành công! Mời sếp đăng nhập.");
            navigate('/login');
        } catch (err) {
            alert("Lỗi đăng ký! Email có thể đã tồn tại.");
        }
    };

    return (
        <div style={authContainer}>
            <form onSubmit={handleRegister} style={authCard}>
                <h2 style={{color: '#00ff88'}}>🚀 Register</h2>
                <input placeholder="User Name" style={inputStyle} onChange={e => setUser({...user, userName: e.target.value})} required />
                <input type="email" placeholder="Email" style={inputStyle} onChange={e => setUser({...user, email: e.target.value})} required />
                <input type="password" placeholder="Password" style={inputStyle} onChange={e => setUser({...user, password: e.target.value})} required />
                <input type="identitycard" placeholder="Identity Card" style={inputStyle} onChange={e => setUser({...user, identitycard: e.target.value})} required />
                <button type="submit" style={buttonStyle}>ĐĂNG KÝ</button>
            </form>
        </div>
    );
};
// (Sếp dùng lại các biến Style ở file Login.js nhé, mình viết gộp cho đỡ tốn chỗ)
const authContainer = { height: '100vh', display: 'flex', justifyContent: 'center', alignItems: 'center', backgroundColor: '#121212', color: 'white', fontFamily: 'Segoe UI' };
const authCard = { backgroundColor: '#1e1e1e', padding: '40px', borderRadius: '12px', width: '350px', textAlign: 'center' };
const inputStyle = { width: '100%', padding: '12px', margin: '10px 0', backgroundColor: '#2a2a2a', border: '1px solid #444', color: 'white', borderRadius: '6px', boxSizing: 'border-box' };
const buttonStyle = { width: '100%', padding: '12px', backgroundColor: '#00ff88', border: 'none', borderRadius: '6px', fontWeight: 'bold', cursor: 'pointer', marginTop: '10px' };

export default Register;