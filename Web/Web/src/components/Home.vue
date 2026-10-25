<template>
    <main class="home-page">
        <section class="hero">
            <p class="eyebrow">INSURANCE SALES PORTAL</p>
            <h1>{{ msg }}</h1>
            <p class="intro">
                Help customers choose an insurance product, calculate a premium,
                prepare a quote and turn an accepted quote into a policy.
            </p>
            <div class="actions">
                <router-link class="primary-action" to="/products">Browse products</router-link>
                <router-link class="secondary-action" to="/policies">Find a policy</router-link>
            </div>
        </section>

        <section class="capabilities" aria-label="Portal capabilities">
            <article class="capability">
                <span class="capability-number">01</span>
                <h2>Products and quotes</h2>
                <p>Review insurance products, choose cover and calculate a customer quote.</p>
            </article>
            <article class="capability">
                <span class="capability-number">02</span>
                <h2>Policies and documents</h2>
                <p>Convert an accepted quote into a policy, search policies and view policy documents.</p>
            </article>
            <article class="capability">
                <span class="capability-number">03</span>
                <h2>Agent workspace</h2>
                <p>Sign in, review sales activity and chat with other agents.</p>
            </article>
        </section>
    </main>
</template>

<script>
    export default {
        name: 'Home',
        props: {
            msg: String
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .home-page {
        max-width: 1080px;
        margin: 0 auto;
        padding: 36px 0 48px;
        text-align: left;
    }

    .hero {
        padding: 52px 56px;
        border-radius: 18px;
        background: linear-gradient(125deg, #102b46, #176b70);
        color: #fff;
    }

    .eyebrow {
        margin: 0 0 14px;
        color: #9ce4d7;
        font-size: 0.8rem;
        font-weight: 700;
        letter-spacing: 0.14em;
    }

    h1 {
        margin: 0;
        font-size: clamp(2rem, 5vw, 3.5rem);
        font-weight: 700;
    }

    .intro {
        max-width: 680px;
        margin: 20px 0 0;
        color: #e0edf1;
        font-size: 1.1rem;
        line-height: 1.7;
    }

    .actions {
        display: flex;
        flex-wrap: wrap;
        gap: 12px;
        margin-top: 30px;
    }

    .actions a {
        display: inline-block;
        padding: 12px 18px;
        border: 1px solid #fff;
        border-radius: 8px;
        color: #fff;
        font-weight: 700;
        text-decoration: none;
    }

    .primary-action {
        background: #fff;
        color: #102b46 !important;
    }

    .actions a:focus-visible {
        outline: 3px solid #ffd166;
        outline-offset: 3px;
    }

    .capabilities {
        display: grid;
        grid-template-columns: repeat(3, minmax(0, 1fr));
        gap: 18px;
        margin-top: 24px;
    }

    .capability {
        padding: 24px;
        border: 1px solid #dce5eb;
        border-radius: 14px;
        background: #fff;
    }

    .capability-number {
        color: #16817b;
        font-size: 0.8rem;
        font-weight: 700;
        letter-spacing: 0.1em;
    }

    .capability h2 {
        margin: 12px 0 8px;
        font-size: 1.15rem;
    }

    .capability p {
        margin: 0;
        color: #526272;
        line-height: 1.6;
    }

    @media (max-width: 700px) {
        .home-page {
            padding: 20px 0 36px;
        }

        .hero {
            padding: 34px 24px;
        }

        .capabilities {
            grid-template-columns: 1fr;
        }
    }
</style>
