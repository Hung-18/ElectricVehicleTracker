import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';

const Login = () => {
    const [credentials, setCredentials] = useState({ email: '', password: '' });
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            // Sếp nhớ check đúng Port của Backend nhé (7123 hay số khác)
            const res = await axios.post('https://localhost:7123/api/Auth/login', credentials);
            localStorage.setItem('token', res.data.token); 
            alert("Đăng nhập thành công!");
            navigate('/dashboard'); 
        } catch (err) {
            alert("Sai email hoặc mật khẩu sếp ơi!");
        }
    };

    return (
        <div style={authContainer}>
            <form onSubmit={handleLogin} style={authCard}>
                <h2 style={{color: '#00ff88'}}>⚡ EV Login</h2>
                <input type="email" placeholder="Email" style={inputStyle} 
                    onChange={e => setCredentials({...credentials, email: e.target.value})} required />
                <input type="password" placeholder="Password" style={inputStyle} 
                    onChange={e => setCredentials({...credentials, password: e.target.value})} required />
                <button type="submit" style={buttonStyle}>ĐĂNG NHẬP</button>
                <p style={{fontSize: '12px', marginTop: '15px'}}>
                    Chưa có tài khoản? <Link to="/register" style={{color: '#00ff88', textDecoration: 'none'}}>Đăng ký ngay</Link>
                </p>
            </form>
        </div>
    );
};

// Style cho nó ngầu
const authContainer = { height: '100vh', display: 'flex', justifyContent: 'center', alignItems: 'center', backgroundColor: '#121212', color: 'white', fontFamily: 'Segoe UI' };
const authCard = { backgroundColor: '#1e1e1e', padding: '40px', borderRadius: '12px', width: '350px', textAlign: 'center', boxShadow: '0 10px 25px rgba(0,0,0,0.5)' };
const inputStyle = { width: '100%', padding: '12px', margin: '10px 0', backgroundColor: '#2a2a2a', border: '1px solid #444', color: 'white', borderRadius: '6px', boxSizing: 'border-box' };
const buttonStyle = { width: '100%', padding: '12px', backgroundColor: '#00ff88', border: 'none', borderRadius: '6px', fontWeight: 'bold', cursor: 'pointer', marginTop: '10px' };

export default Login;