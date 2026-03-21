import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Login from './Components/Login';
import Register from './Components/Register';

// Tạm thời mình chỉ test Login/Register, tí nữa mình đưa Dashboard vào sau nhé
function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        {/* Nếu gõ bậy bạ nó tự quay về trang Login */}
        <Route path="*" element={<Navigate to="/login" />} />
      </Routes>
    </Router>
  );
}

export default App;