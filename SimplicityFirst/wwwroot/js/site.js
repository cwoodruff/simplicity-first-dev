// Simplicity-First — Minimal site interactivity
(function () {
    'use strict';

    // --- Intersection Observer for scroll animations ---
    const observer = new IntersectionObserver(
        (entries) => {
            entries.forEach((entry) => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('is-visible');
                    observer.unobserve(entry.target);
                }
            });
        },
        { threshold: 0.1, rootMargin: '0px 0px -40px 0px' }
    );

    document.querySelectorAll('.animate-on-scroll').forEach((el) => {
        observer.observe(el);
    });

    // --- Sticky nav background on scroll ---
    const nav = document.getElementById('main-nav');
    if (nav) {
        window.addEventListener('scroll', () => {
            if (window.scrollY > 50) {
                nav.classList.add('nav-scrolled');
            } else {
                nav.classList.remove('nav-scrolled');
            }
        }, { passive: true });
    }

    // --- Mobile menu toggle ---
    const menuBtn = document.getElementById('mobile-menu-btn');
    const mobileMenu = document.getElementById('mobile-menu');
    if (menuBtn && mobileMenu) {
        menuBtn.addEventListener('click', () => {
            const isOpen = mobileMenu.classList.toggle('is-open');
            menuBtn.classList.toggle('menu-open');
            menuBtn.setAttribute('aria-expanded', isOpen);
            document.body.style.overflow = isOpen ? 'hidden' : '';
        });

        mobileMenu.querySelectorAll('a').forEach((link) => {
            link.addEventListener('click', () => {
                mobileMenu.classList.remove('is-open');
                menuBtn.classList.remove('menu-open');
                menuBtn.setAttribute('aria-expanded', 'false');
                document.body.style.overflow = '';
            });
        });
    }

    // --- Accordion toggle ---
    document.querySelectorAll('.accordion-trigger').forEach((trigger) => {
        trigger.addEventListener('click', () => {
            const content = document.getElementById(trigger.getAttribute('aria-controls'));
            const isOpen = trigger.getAttribute('aria-expanded') === 'true';
            trigger.setAttribute('aria-expanded', !isOpen);
            if (content) {
                content.classList.toggle('is-open');
            }
        });
    });

    // --- Smooth scroll for anchor links (fallback for older browsers) ---
    document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
        anchor.addEventListener('click', (e) => {
            const targetId = anchor.getAttribute('href');
            if (targetId === '#') return;
            const target = document.querySelector(targetId);
            if (target) {
                e.preventDefault();
                target.scrollIntoView({ behavior: 'smooth', block: 'start' });
            }
        });
    });

    // --- Thank-you modal ---
    const modal = document.getElementById('thank-you-modal');
    const modalCloseBtn = document.getElementById('modal-close-btn');

    function openModal() {
        if (!modal) return;
        modal.classList.add('is-open');
        modal.setAttribute('aria-hidden', 'false');
        document.body.style.overflow = 'hidden';
        if (modalCloseBtn) modalCloseBtn.focus();
    }

    function closeModal() {
        if (!modal) return;
        modal.classList.remove('is-open');
        modal.setAttribute('aria-hidden', 'true');
        document.body.style.overflow = '';
    }

    if (modalCloseBtn) {
        modalCloseBtn.addEventListener('click', closeModal);
    }

    if (modal) {
        modal.addEventListener('click', (e) => {
            if (e.target === modal || e.target.classList.contains('modal-backdrop')) {
                closeModal();
            }
        });
    }

    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && modal && modal.classList.contains('is-open')) {
            closeModal();
        }
    });

    // --- HTMX subscribe callback ---
    window.onSubscribeComplete = function (event) {
        const response = document.getElementById('subscribe-response');
        if (!response) return;

        const showModal = response.querySelector('[data-show-modal="true"]');
        if (showModal) {
            const form = document.getElementById('subscribe-form');
            if (form) form.style.display = 'none';
            openModal();
        }
    };
})();
